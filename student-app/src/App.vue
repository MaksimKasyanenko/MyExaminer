<script>
export default {
  data() {
    return {
      nameRequired: false,
      tokenRequired: false,
      fNameKey: "fName",
      sNameKey: "sName",
      greatingsText: "Система дистанційного тестування учнів",

      firstName: "",
      secondName: "",
      accessToken: "",

      loading: false
    };
  },
  methods: {
    startExam() {
      this.loading = true;
      localStorage.setItem(this.fNameKey, this.firstName);
      localStorage.setItem(this.sNameKey, this.secondName);
    }
  },
  beforeMount() {
    const firstName = localStorage.getItem(this.fNameKey);
    const secondName = localStorage.getItem(this.sNameKey);

    this.nameRequired = !firstName || !secondName;

    this.firstName = firstName;
    this.secondName = secondName;

    if(!this.nameRequired) this.greatingsText = `Привіт, ${this.firstName}`;

    const accessToken = new URLSearchParams(window.location.search).get('accessToken');
    if(accessToken) this.accessToken = accessToken;
    this.tokenRequired = !accessToken;
  }
};
</script>

<template>
  <main>
    <div class="container">
      <div class="start-test-form cover text-white rounded p-3 p-md-4 mt-5">
        <div class="text-center">
          <h1 class="fw-bold mb-3">{{ greatingsText }}</h1>
          <p v-if="nameRequired">Для доступу до тесту заповніть форму</p>
          <p v-else-if="tokenRequired">Для доступу до тесту введіть ключ запрошення</p>
        </div>
        <form class="mt-5" v-on:submit.prevent="startExam">
          <input v-if="nameRequired" v-model="secondName" class="form-control mb-2" type="text" placeholder="Прізвище"
            required />
          <input v-if="nameRequired" v-model="firstName" class="form-control mb-2" type="text" placeholder="Ім'я"
            required />
          <input v-if="tokenRequired" v-model="accessToken" class="form-control" type="text" placeholder="Ключ запрошення" required />
          <div class="text-center">
            <button class="btn btn-primary mt-3" type="submit">Розпочати тест</button>
          </div>
        </form>
      </div>
    </div>
    <loader v-if="loading" />
  </main>
</template>

<style scoped>
.start-test-form {
  max-width: 600px;
  margin: 0 auto;
}
</style>
