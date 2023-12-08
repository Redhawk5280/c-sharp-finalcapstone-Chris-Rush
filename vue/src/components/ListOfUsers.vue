<template>
  <h1>User List</h1>
  <section class="userList">
    <user-card 
        v-for="user in filteredUsers" 
        v-bind:key="user.email"
        v-bind:user="user" 
        class="userCard"
      />
  </section>
</template>




<script>
import UserCard from "../components/UserCard.vue"

export default {
  components: {
    UserCard
  },
  props: {
    users: Array
  },
  computed:{
    filteredUsers(){
      
        return this.users.filter(user=>{
          return user.role !=='deactivated';
        })
      }
  }

}

</script>

<style scoped>

/* */


  .userList {
    height: 100%;
    width: 100%;
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: 1fr;
    grid-gap: 1rem;
    place-items: center;
    margin: auto;
  } 

  .userList > {
    height:80%;
  } 

  h1 {
    font-family: var(--font-h1);
  }


  @media only screen and (max-width: 639px) {
    .userList {
      grid-template-columns: 1fr;
    }
  }

  @media only screen and (min-width: 640px) and (max-width: 1024px) {
    /* Styles for landscape smartphones and tablets in portrait mode */
    .userList {
      grid-template-columns: repeat(2, 1fr);
    }
  }

  @media only screen and (min-width: 1024px) and (max-width: 1439px) {
    /* Styles for larger devices like tablets in landscape and smaller desktops */
    .userList {
      grid-template-columns: repeat(3, 1fr);
    }
  }

  @media only screen and (min-width: 1440px) {
    /* Styles for extra large devices like large desktops and TVs */
    .userList {
      grid-template-columns: repeat(3, 1fr);
    }
  }

/* */

</style>
