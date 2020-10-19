const userKey = "@nordtv/user";
const tokenKey = "@nordtv/token";

export const getUser = () => JSON.parse(localStorage.getItem(userKey));

export const setUser = (user) =>
  localStorage.setItem(userKey, JSON.stringify(user));

export const setToken = (token) => localStorage.setItem(tokenKey, token);

export const getToken = () => localStorage.getItem(tokenKey);

export const login = ({ user, token }) => {
  setUser(user);
  setToken(token);
};

export const logout = () => {
  localStorage.removeItem(userKey);
  localStorage.removeItem(tokenKey);
};
