<template>
  <div class="volunteer-view">
    <generic-form
      class="volunteer-signup"
      title="Volunteer Signup"
      :fields="formFields"
      @submit="handleFormSubmit"
    />
  </div>
</template>

<script>
import GenericForm from '../components/Form.vue'; // Adjust the path as necessary

export default {
  components: {
    GenericForm
  },
  data() {
    return {
      formFields: [
        { name: 'name', label: 'Name', type: 'text', required: true },
        { name: 'email', label: 'Email', type: 'email', required: true },
        { name: 'weekday_available', label: 'Available Weekdays?', type: 'checkbox', required: true },
        { name: 'weekend_available', label: 'Available Weekends?', type: 'checkbox', required: true },
        { name: 'interest', label: 'Why are you interested in helping?', type: 'textarea', required: false }
      ]
    };
  },
  created() { 
    console.log(this.formFields);
  },
  methods: {
    handleFormSubmit(formData) {
      console.log('Form Submitted:', formData);
      // Handle form submission, e.g., send data to an API
    },
  }
};
</script>

<style scoped>
.volunteer-signup {
  max-width: 400px;
  margin: 3rem auto;
  padding: 20px;
  box-shadow: var(--generic-shadow);
  border-radius: 1rem;
}

/* Rest of your styles */
</style>
