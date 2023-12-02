<template>
  <div id="capstone-app">
    <div id="nav">
      <div>
        <p>LOGO</p>
      </div>
      <div>
        <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>

      </div>
    </div>
    <router-view />
  </div>
</template>

<script>

</script>

<style scoped>
  #nav{
    width: 100%;
    border: 1px solid black;
    display: flex;
    align-items: center;
    justify-content: space-between;
  }
</style>


