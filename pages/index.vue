<template>
  <v-sheet class="mx-auto h-15 text-center" width="500" height="500" >
    <v-form ref="form" v-model="valid">
      <v-text-field
        v-model="name"
        :min="5"
        :rules="nomeRules"
        label="Seu Nome"
        required
      ></v-text-field>

      <v-text-field
        v-model="email"
        :rules="emailRules"
        label="Seu Email"
        required
      ></v-text-field>

      <div class="d-flex flex-column">
        <v-btn
          class="mt-4"
          color="primary"
          :disabled="!valid"
          @click="submit"
        >
          Submit
        </v-btn>
      </div>
      <h1> Bem Vindo</h1>
      <h1> Faça Seu Login ...</h1>
    </v-form>
  </v-sheet>
 
</template>

<script>

export default{
  data:() =>({
    
    name:'',
    nameRules:[
      v => !!v || 'name is required',
      v => (v && v.length > 5) || 'name must be less than 10 characters',
    ],
    email:'',
    emailRules:[
      v => !!v || 'email is required',
      v => /.+@.+\..+/.test(v) || 'email must be less than 10 characters',
    ],
  }),
  methods:{
   async submit(){
      debugger
      try{
     let res = await this.$axios({
        url:"https://localhost:7051/Categoria",
        method:'POST',
        
        data:{
          name:this.name,
          email:this.email
        }
      })
      debugger
    } catch{}
    }
  }
}

  
</script>


<style scoped>
button {
  border-radius: 55px;
  width: 100%;
  
}
</style>







