<template>
  <h1>User List</h1>
  <section>
    <user-card 
        v-for="user in users" 
        v-bind:key="user.id"
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
  }
}

</script>

<style scoped>

</style>
