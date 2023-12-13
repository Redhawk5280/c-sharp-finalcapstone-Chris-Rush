<template>
    <div>
        <h1>Thank you for your submission!</h1>
        <button :onclick="goHome">Home</button>
    </div>

</template>

<script>
export default {
    methods: {
        goHome() {
            this.$router.push({"name": "home"});
        }
    }
}
</script>

<style scoped>

div {
    background-color: var(--card-background);
    width: 50%;
    margin: auto;
    padding: 1rem;
    border-radius: 1rem;
    margin-top: 3rem;
    display: flex;
    flex-direction: column;
    align-items: center;
}

button {
    font-family: inherit;
    width: 6rem;
    height: 2rem;
    border-radius: 0.5rem;
    border: none;
    color: var(--company-color-1);
    font-size: 1rem;
}

</style>