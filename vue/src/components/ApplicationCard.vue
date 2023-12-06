<template>
  <section 
    class="applicationCard" 
  >
    <h1>Name: {{application.appName}}</h1>
    <p>Email: {{application.appEmail}}</p>
    <p v-if="application.weekdayAvailability">Weekday Availability: Yes</p>
    <p v-else>Weekday Availability: No</p>
    <p v-if="application.weekendAvailability">Weekend Availability: Yes</p>
    <p v-else>Weekend Availability: No</p>
    <p>Interest: {{application.interest}}</p>
    <div v-if="$store.state.user.role === 'admin'">
      <div v-if="application.isApproved == false">
          <button id="acceptBtn">Accept</button>
          <button id="denyBtn">Deny</button>
      </div>
      <button v-else id="deactivateBtn">Deactivate</button>
    </div>
  </section>
</template>

<script>


export default {
  props: [
    'application'
  ],
  methods: {
    
  },
  computed: { 
  }
}
</script>

<style scoped>
  .applicationCard {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    border-radius: 1rem;
    box-shadow: var(--generic-shadow);
    background-color: var(--company-color-1);
    overflow: none;
    position: relative;
    height: 100%;
    width: 100%;
    padding: 20% 0;
    border-radius: 1rem;
    font-size: 2rem;
  }

  .applicationCard h1,h2,p{
    margin: 0;
    padding: 0;
    font-family: var(--card-body-font);
    color: var(--company-color-2);
    max-width: 100%;
  }

  button {
    border: none;
    padding: 8px 16px;
    border-radius: 1rem;
    font-size: 2rem;
  }



  
</style>