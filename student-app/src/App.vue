<script>
export default {
  data() {
    return {
      nameRequired: false,
      fNameKey: "fName",
      sNameKey: "sName",

      firstName: "",
      secondName: "",
      accessToken: ""
    };
  },
  methods: {
    startExam() {
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

    const accessToken = new URLSearchParams(window.location.search).get('accessToken');
    if(accessToken) this.accessToken = accessToken;
  }
};
</script>

<template>
  <main>
    <div class="container">
      <div class="start-test-form text-white rounded p-3 p-md-4 mt-5">
        <div class="text-center">
          <h1 class="fw-bold mb-3">Система дистанційного тестування учнів</h1>
          <p v-if="nameRequired">Для доступу до тесту заповніть форму</p>
          <p v-else-if="!accessToken">Для доступу до тесту введіть ключ запрошення</p>
        </div>
        <form class="mt-5" v-on:submit.prevent="startExam">
          <input v-if="nameRequired" v-model="secondName" class="form-control mb-2" type="text" placeholder="Прізвище"
            required />
          <input v-if="nameRequired" v-model="firstName" class="form-control mb-2" type="text" placeholder="Ім'я"
            required />
          <input v-if="!accessToken" v-model="accessToken" class="form-control" type="text" placeholder="Ключ запрошення" required />
          <div class="text-center">
            <button class="btn btn-primary mt-3" type="submit">Розпочати тест</button>
          </div>
        </form>
      </div>
    </div>
  </main>
</template>

<style scoped>
.start-test-form {
  background-color: #333333cb;
  backdrop-filter: blur(4px);
  max-width: 600px;
  margin: 0 auto;
}
</style>
