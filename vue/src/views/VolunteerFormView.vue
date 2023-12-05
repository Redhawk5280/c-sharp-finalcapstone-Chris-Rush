<template>
  <div class="volunteer-view">
    <generic-form
      class="volunteer-signup"
      title="Volunteer Signup"
      :fields="formFields"
      
    />
  </div>
</template>

<script>
import GenericForm from '../components/Form.vue'; // Adjust the path as necessary
import VolunteerService from '../services/VolunteerService';

export default {
  components: {
    GenericForm
  },
  data() {
    return {
      formFields: [
        { name: 'AppName', label: 'Name', type: 'text', required: true },
        { name: 'AppEmail', label: 'Email', type: 'email', required: true },
        { name: 'WeekdayAvailable', label: 'Available Weekdays?', type: 'checkbox', required: false },
        { name: 'WeekendAvailable', label: 'Available Weekends?', type: 'checkbox', required: false },
        { name: 'Interest', label: 'Why are you interested in helping?', type: 'textarea', required: false }
      ]
    };
  },
  created() { 

    console.log(this.formFields);
  },
  methods: {
  
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
