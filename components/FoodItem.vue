<template>
    <div class="food-item">
      <p><strong>{{ foodItem.name }}</strong></p>
      <p>Calories: {{ foodItem.calories }}</p>
      <p>Fat: {{ foodItem.fat }}</p>
      <p>Carbs: {{ foodItem.carbs }}</p>
      <p>Protein: {{ foodItem.protein }}</p>
      <button @click="$emit('edit', foodItem)">Edit</button>
      <button @click="$emit('delete', foodItem.id)">Delete</button>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      foodItem: {
        type: Object,
        required: true,
      },
    },
  }
  </script>
  