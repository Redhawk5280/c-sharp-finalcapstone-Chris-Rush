<template>
  <toast-container
    containerId="containerId"
  />
</template>

<script>

import ToastContainer  from "vue3-toastify";
import "vue3-toastify/dist/index.css";

export default {
  props: [
    ''
  ],
  components: {
    ToastContainer,
  }
}

</script>

<style scoped>
</style>