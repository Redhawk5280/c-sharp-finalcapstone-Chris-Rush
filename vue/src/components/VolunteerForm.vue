<template>
  <div class="volunteer-signup">
    <generic-form
      title="Volunteer Signup"
      :fields="formFields"
      :alertMessage="alertMessage"
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
        { name: 'phone', label: 'Phone Number', type: 'tel', required: true }
        
      ],
      alertMessage: '',
    };
  },
  methods: {
    handleFormSubmit(formData) {
      console.log('Form Submitted:', formData);
      // Handle form submission, e.g., send data to an API
    }
  }
};
</script>

<style scoped>
.volunteer-signup {
  max-width: 400px;
  margin: auto;
  padding: 20px;
  box-shadow: var(--generic-shadow);
  border-radius: 1rem;
}

/* Rest of your styles */
</style>
