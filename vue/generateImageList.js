const fs = require('fs');
const path = require('path');

const imageDirectory = path.join(__dirname, 'public/PetPics-Copy');
const outputFilePath = path.join(__dirname, 'src/assets/imagePaths.json');

fs.readdir(imageDirectory, (err, files) => {
  if (err) {
    console.error('Error reading the images directory:', err);
    return;
  }

  const imagePaths = files.map(file => `/PetPics-Copy/${file}`);
  fs.writeFile(outputFilePath, JSON.stringify(imagePaths, null, 2), (err) => {
    if (err) {
      console.error('Error writing the JSON file:', err);
    } else {
      console.log('Image paths JSON file generated successfully!');
    }
  });
});
