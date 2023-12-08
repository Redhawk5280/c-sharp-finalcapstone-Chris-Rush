<template>
  <h1>User List</h1>
  <section>
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

</style>
