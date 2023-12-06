<template>
  <div class="applicationList">
      <application-card 
        v-for="application in applications" 
        v-bind:key="application.appId"
        v-bind:application="application" 
        class="applicationCard"
      />
  </div>
</template>

<script>

  import ApplicationCard from "../components/ApplicationCard.vue"
  import volunteerService from "../services/VolunteerService";
export default {
      props: {
        applications: Array,
      },    
      components: {
        ApplicationCard,
      },
      data() { 
        return {
          isLoading: false,
        }
    },
    methods: {
    },
  }
</script>

<style scoped>
  .applicationList {
    height: 100%;
    width: 100%;
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: 1fr;
    grid-gap: 3rem;
    place-items: center;
    margin: 10% auto;
  }

  .applicationList > {
    height:80%;
  } 


  @media only screen and (max-width: 639px) {
    .applicationList {
      grid-template-columns: 1fr;
    }
  }

  @media only screen and (min-width: 640px) and (max-width: 1024px) {
    /* Styles for landscape smartphones and tablets in portrait mode */
    .applicationList {
      grid-template-columns: repeat(2, 1fr);
    }
  }

  @media only screen and (min-width: 1024px) and (max-width: 1439px) {
    /* Styles for larger devices like tablets in landscape and smaller desktops */
    .applicationList {
      grid-template-columns: repeat(2, 1fr);
    }
  }

  @media only screen and (min-width: 1440px) {
    /* Styles for extra large devices like large desktops and TVs */
    .applicationList {
      grid-template-columns: repeat(3, 1fr);
    }
  }

</style>