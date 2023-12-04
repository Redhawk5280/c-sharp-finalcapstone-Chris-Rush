import axios from 'axios';

export default {

  uploadImage(image) {
    return axios.post('/image', image);
  },

  getImagesByAnimalId(id) {
    return axios.get(`/image/${id}`);
  },
}
