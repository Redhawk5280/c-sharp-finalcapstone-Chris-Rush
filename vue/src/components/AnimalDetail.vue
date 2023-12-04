<template>
  <div class="details">
    <h1>Animal Details</h1>
    <img :src="animal.photos[0].imageString" alt="">
    <p>ID: {{ this.animal.id }}</p>
    <p>Name: {{ this.animal.name }}</p>
  </div>
</template>

<script>
export default {
  props: ['animal'],
  computed : {
    photoPath() {
      if(this.animal && this.animal.photos){
        return this.animal.photos[0].imageString;
      } else{
        return "";
      }
    }
  }
}
</script>

<style scoped>
  .details{
    text-align: center;
  }

  img {
    width: 500px;
    height:  500px;

  }

</style>