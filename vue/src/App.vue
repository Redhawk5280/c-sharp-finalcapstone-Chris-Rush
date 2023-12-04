<template>
  <div id="capstone-app">
    <header-component/>
    <router-view />
  </div>
</template>

<script>
import HeaderComponent from "./components/Header.vue"

export default {
  components: {
    HeaderComponent
  }
}

</script>

<style scoped>

  
</style>


