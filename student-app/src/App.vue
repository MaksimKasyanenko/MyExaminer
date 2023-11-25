<script>
  export default {
    data() {
      return {
        nameRequired: false,
        fNameKey: "fName",
        sNameKey: "sName",

        firstName: null,
        secondName: null
      };
    },
    methods: {
      checkName() {
        const firstName = localStorage.getItem(this.fNameKey);
        const secondName = localStorage.getItem(this.sNameKey);

        this.nameRequired = !firstName || !secondName;
      }
    },
    beforeMount() {
      this.checkName();
    }
  };
</script>

<template>
  <main>
    <div class="container">
      <div class="start-test-form text-white rounded p-3 mt-5">
        <div class="text-center">
          <h1 class="fw-bold mb-3">Система дистанційного тестування учнів</h1>
          <p v-if="nameRequired" class="mb-5">Для доступу до тесту заповніть форму</p>
          <p v-else="nameRequired" class="mb-5">Для доступу до тесту введіть ключ запрошення</p>
        </div>
        <form>
          <input v-if="nameRequired" class="form-control mb-2" type="text" placeholder="Прізвище" />
          <input v-if="nameRequired" class="form-control mb-2" type="text" placeholder="Ім'я" />
          <input class="form-control mb-3" type="text" placeholder="Ключ запрошення" />
          <div class="text-center">
            <button class="btn btn-primary" type="submit">Розпочати тест</button>
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
