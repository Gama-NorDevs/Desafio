export const getUser = () => JSON.parse(localStorage.getItem("@nordtv/user"));

export const setUser = (user) =>
  localStorage.setItem("@nordtv/user", JSON.stringify(user));

export const login = (user) => setUser(user);

export const logout = () => localStorage.removeItem("@nordtv/user");
