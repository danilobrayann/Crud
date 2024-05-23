<template>
    <v-sheet class="mx-auto h-15" width="800">
  
      <v-form ref="form">
        <v-text-field
          v-model="name"
          :counter="10"
          :rules="nameRules"
          label="Name"
          required
        ></v-text-field>
  
        <v-select
          v-model="select"
          :items="items"
          :rules="[v => !!v || 'Item is required']"
          label="Item"
          required
        ></v-select>
  
      
  
        <div class="d-flex flex-column">
          <v-btn
            class="mt-4"
            color="success"
            block
            @click="validate"
          >
            Validate
          </v-btn>
  
          <v-btn
            class="mt-4"
            color="error"
            block
            @click="reset"
          >
            Reset Form
          </v-btn>
  
          <v-btn
            class="mt-4"
            color="warning"
            block
            @click="resetValidation"
          >
            Reset Validation
          </v-btn>
        </div>
      </v-form>
    </v-sheet>
  </template>
  <script>
    export default {
      data: () => ({
        name: '',
        nameRules: [
          v => !!v || 'Name is required',
          v => (v && v.length <= 10) || 'Name must be less than 10 characters',
        ],
        select: null,
        items: [
          'Item 1',
          'Item 2',
          'Item 3',
          'Item 4',
        ],
        checkbox: false,
      }),
  
      methods: {
        async validate () {
          const { valid } = await this.$refs.form.validate()
  
          if (valid) alert('Form is valid')
        },
        reset () {
          this.$refs.form.reset()
        },
        resetValidation () {
          this.$refs.form.resetValidation()
        },
      },
    }
  </script>

<template>
    <v-sheet class="mx-auto " width="500" >
  
      <v-form ref="form">
        <v-text-field
          v-model="name"
          :counter="10"
          :rules="nameRules"
          label="Seu Nome"
          required
          
        ></v-text-field>
  
        <v-select
          v-model="select"
          :items="items"
          :rules="[v => !!v || 'Prenchimento obrigatorio']"
          label="Cor Prefrida"
          required
        ></v-select>
  
      
  
        <div class="d-flex flex-column">
          <v-btn
            class="mt-4"
            color="success"
            block
            @click="validate"
          >
            Validate
          </v-btn>
  
          <v-btn
            class="mt-4 "
            color="error"
            block
            @click="reset"
          >
            Reset Form
          </v-btn>
  
         
        </div>
      </v-form>
    </v-sheet>
  </template>
  <script>
    export default {
      data: () => ({
        name: '',
        nameRules: [
          v => !!v || 'Prenchimento obrigatorio',
          v => (v && v.length <= 10) || 'Name must be less than 10 characters',
        ],
        select: null,
        items: [
          'Azul',
          'Preto',
          'Branco',
          'Verde',
        ],
        checkbox: false,
      }),
  
      methods: {
        async validate () {
          const { valid } = await this.$refs.form.validate()
  
          if (valid) alert('Form is valid')
        },
        reset () {
          this.$refs.form.reset()
        },
        resetValidation () {
          this.$refs.form.resetValidation()
        },
      },
    }
  </script>


<style scoped>
button {
  border-radius: 55px;
  width: 2px;
}
</style>