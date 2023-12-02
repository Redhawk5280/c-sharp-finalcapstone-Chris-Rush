<template>
  <div>
    <h2>Animal Details</h2>
    <p>ID: {{ animal.id }}</p>
    <p>Name: {{ animal.name }}</p>
  </div>
</template>

<script>
export default {
  props: ['animal'],

}
</script>