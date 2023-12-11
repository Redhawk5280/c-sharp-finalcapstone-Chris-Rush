<template> 
<div id ="home">
    <div id="homeImg">
        <img  src="../assets/building/wow.jpg" alt="building">
    </div>
<div>  
    <h1>About Us</h1>
    <div id="paragraph">
        <p id="p1"> 
            &nbsp;&nbsp;&nbsp;&nbsp;Welcome to Paw Prints Pet Rescue, where every paw print tells a story of hope and second chances! Our journey started in the heart of Cleveland, Ohio, a city pulsating with love for our furry friends. Established in 2010, Paw Prints Pet Rescue was born out of a shared passion for creating a haven where wagging tails, gentle purrs, and happy squeaks harmonize into a symphony of love.
        </p>
        <p id="p2">

            &nbsp;&nbsp;&nbsp;&nbsp;Dogs, cats, and guinea pigs, oh my! Paw Prints Pet Rescue is a haven for all shapes and sizes of furry companions. From energetic pups ready for a game of fetch to sophisticated felines with a penchant for purring conversations, and the adorable guinea pigs who bring a touch of whimsy to our rescue family, we welcome them all with open arms and ample belly rubs.
            Located in the heart of Cleveland, our rescue center is not just a place; it's a warm embrace for pets seeking a second chance and for humans eager to share their lives with a furry friend. Join us in our mission to turn every paw print into a tale of joy and a journey of love at Paw Prints Pet Rescue!
        </p>
    </div>
</div>
    
</div>


</template>

<style scoped > 
#home{
    font-family: var(--card-body-font);
    margin: 1.5rem 15%;
    display:flex;
    flex-direction: column;
    justify-content: center;
    background-color: white;
    border-radius: 1rem;
    padding: 1rem;
}
#paragraph{
    font-family: var(--card-body-font);
    font-weight: bold;
}

#homeImg{
    height: auto;
    width: 70%;
    margin: auto;
  
}
img{
    height: 100%;
    object-fit: fill;
    width:100%;
    border-radius: 1rem;
    box-shadow: var(--generic-shadow);

    
    
}
h1{
    text-align: center;
    text-decoration: underline;
    background-color: var(--company-color-2);
    object-fit: cover;
    border-radius: 1rem;
}






</style>