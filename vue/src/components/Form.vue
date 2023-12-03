<template>
  <div class="generic-form">
    <h1>{{ title }}</h1>

    <div
      v-if="alertMessage"
      class="alert"
    >
      {{alertMessage}}
    </div>
    <form @submit.prevent="submitForm">
      <div class="form-group" v-for="field in fields" :key="field.name">
        <label :for="field.name">{{ field.label }}:</label>
        <input
          :type="field.type"
          :id="field.name"
          :placeholder="field.placeholder"
          v-model="formData[field.name]"
          :required="field.required"
        />
      </div>
      <button type="submit">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  props: {
    title: String,
    fields: Array,
    alertMessage: String
  },
  data() {
    return {

    };
  },
  computed: {
  formData() {
    return this.fields.reduce((obj, field) => {
      obj[field.name] = field.value || '';
      return obj;
    }, {});
  }
},

  methods: {
    submitForm() {
      this.$emit('submit', this.formData);
    }
  }
};
</script>

<style scoped>
  h1 {
  text-align:center;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
}

input {
  width: 96%;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button[type="submit"] {
  background-color: #4CAF50;
  color: white;
  padding: 10px 15px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  width: 100%;
}

button[type="submit"]:hover {
  background-color: #45a049;
}

.alert {
  color: red;
  margin-bottom: 1rem;
}
</style>
