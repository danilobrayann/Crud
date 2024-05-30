<template>
  <div>
    <h1>Food Items</h1>
    <div v-if="loading">Loading...</div>
    <div v-else>
      <v-card v-for="item in foodItems" :key="item.id" class="mb-3">
        <v-card-title>{{ item.name }}</v-card-title>
        <v-card-text>
          <p>Calories: {{ item.calories }}</p>
          <p>Fat: {{ item.fat }}</p>
          <p>Carbs: {{ item.carbs }}</p>
          <p>Protein: {{ item.protein }}</p>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="editItem(item)">Edit</v-btn>
          <v-btn color="error" @click="deleteItem(item.id)">Delete</v-btn>
        </v-card-actions>
      </v-card>
    </div>
    <h2>Add New Food Item</h2>
    <v-form @submit.prevent="addItem">
      <v-text-field v-model="newItem.name" label="Name" required></v-text-field>
      <v-text-field v-model="newItem.calories" label="Calories" type="number" required></v-text-field>
      <v-text-field v-model="newItem.fat" label="Fat" type="number" required></v-text-field>
      <v-text-field v-model="newItem.carbs" label="Carbs" type="number" required></v-text-field>
      <v-text-field v-model="newItem.protein" label="Protein" type="number" required></v-text-field>
      <v-btn type="submit" color="primary">Add Item</v-btn>
    </v-form>
  </div>
</template>

<script>
import FoodItem from '~/components/FoodItem.vue';

export default {
  components: {
    FoodItem,
  },
  data() {
    return {
      foodItems: [],
      loading: true,
      newItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
    };
  },
  async fetch() {
    try {
      const response = await this.$axios.get('/Food');
      this.foodItems = response.data;
    } catch (error) {
      console.error(error);
    } finally {
      this.loading = false;
    }
  },
  methods: {
    async addItem() {
      try {
        const response = await this.$axios.post('/Food',);
        console.log(response.data, this.newItem);
        this.foodItems.push(response.data);
        this.newItem = {
          name: '',
          calories: 0,
          fat: 0,
          carbs: 0,
          protein: 0,
        };
      } catch (error) {
        console.error(error);
      }
    },
    async deleteItem(id) {
      try {
        await this.$axios.delete(`/Food/${id}`);
        this.foodItems = this.foodItems.filter(item => item.id !== id);
      } catch (error) {
        console.error(error);
      }
    },
    editItem(foodItem) {
      const editedItem = { ...foodItem }; // Clone the foodItem to avoid direct mutations
      editedItem.name = prompt('Edit name:', editedItem.name) || editedItem.name;
      editedItem.calories = prompt('Edit calories:', editedItem.calories) || editedItem.calories;
      editedItem.fat = prompt('Edit fat:', editedItem.fat) || editedItem.fat;
      editedItem.carbs = prompt('Edit carbs:', editedItem.carbs) || editedItem.carbs;
      editedItem.protein = prompt('Edit protein:', editedItem.protein) || editedItem.protein;
      
      this.updateItem(editedItem);
    },
    async updateItem(editedItem) {
      try {
        await this.$axios.put(`/Food/${editedItem.id}`, editedItem);
        const index = this.foodItems.findIndex(item => item.id === editedItem.id);
        this.$set(this.foodItems, index, editedItem);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
</script>

<style scoped>
/* Estilos específicos do componente */
</style>
