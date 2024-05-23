<template>
  <v-sheet class="mx-auto h-15" width="500">
    <v-form ref="form" v-model="valid">
      <v-text-field
        v-model="categoria.nome"
        :counter="10"
        :rules="nomeRules"
        label="Seu Nome"
        required
      ></v-text-field>
      
      <v-text-field
        v-model="categoria.email"
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
    </v-form>
  </v-sheet>
</template>

<script>
import axios from 'axios';

export default {
  data: () => ({
    valid: true,
    categoria: {
      nome: "",
      email: "",
    },
    nomeRules: [
      v => !!v || "Nome é obrigatório",
      v => (v && v.length >= 5) || "Nome precisa de ter pelo menos 5 caracteres",
    ],
    emailRules: [
      v => !!v || "Email é obrigatório",
      v => /.+@.+\..+/.test(v) || "Email deve ser válido",
    ],
    categorias: [
      {
        nome: "Categoria 1",
        descricao: "descrição da categoria 1",
      },
    ],
  }),
  methods: {
    async submit() {
      if (!this.$refs.form.validate()) {
        alert("Preencha o formulário corretamente.");
        return;
      }
      
      try {
        let response = await axios.post('https://localhost:7023/Categoria', this.categoria);

        alert('Formulário enviado com sucesso');
        console.log(response);

        let responseGet = await axios.get('https://localhost:7023/Categoria');
        this.categorias = responseGet.data;
      } catch (error) {
        console.error('Erro ao enviar o formulário:', error);
        alert('Falha ao enviar o formulário');
      }
    },
  },
};
</script>

<style scoped>
button {
  border-radius: 55px;
  width: 100%;
}
</style>








