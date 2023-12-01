import axios from 'axios'

const http = axios.create({
    baseURL: "http://localhost:5000/images"
});

export default {

    addImage(file) {
        const form = new FormData();
        form.append("data", file);
        return http.post("/", form, {
            headers: {
                "content-type": 'multipart/form-data'
            }
        });
    }

}