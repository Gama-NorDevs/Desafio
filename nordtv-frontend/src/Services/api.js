import axios from "axios";
import { getToken } from "./user";

const options = { baseURL: "http://localhost:51492/api" };

const api = axios.create(options);

api.interceptors.request.use(async (config) => {
  const token = getToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export { api };
