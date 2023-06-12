
import axios from 'axios'

const client = axios.create({
    baseURL: "http://localhost:5000/Task",
    json: true
})

export default {
    async execute(method, resource, data) {
        return client({
            method,
            url: resource,
            data
        }).then(req => {
            return req.data
        });
    },

    getAll() {
        return this.execute('get', '/');
    },

    get(id) {
        return this.execute('get', `/${id}`);
    },

    create(data) {
        return this.execute('post', '/', data);
    },

    update(data) {
        return this.execute('put', '/', data);
    },

    delete(id) {
        return this.execute('delete', `/${id}`);
    },

    complete(id) {
        return this.execute('post', `/complete/${id}`);
    }
}