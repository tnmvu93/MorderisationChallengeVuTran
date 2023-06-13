import axios from "axios";

const client = axios.create({
  baseURL: "https://localhost:5679/Task",
  headers: {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
  },
});

class ApiService {
  execute(method: string, resource: string, data?: any) {
    return client({
      method,
      url: resource,
      data,
    }).then((response) => {
      return response.data;
    });
  }

  getAll() {
    return this.execute("get", "/");
  }

  get(id: number) {
    return this.execute("get", `/${id}`);
  }

  create(data: any) {
    return this.execute("post", "/", data);
  }

  update(data: any) {
    return this.execute("put", "/", data);
  }

  delete(id: number) {
    return this.execute("delete", `/${id}`);
  }

  complete(data: any) {
    return this.execute("post", `complete`, data);
  }
}
export default new ApiService();
