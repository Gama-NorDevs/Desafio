import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { getUser, setUser } from "../../Services/user";
import Login from "./Login";
import Register from "./Register";

// import { Container } from './styles';

function Auth() {
  const history = useHistory();
  const [register, setRegister] = useState(false);

  useEffect(() => {
    setUser({
      name: "teste",
      email: "teste2@teste.com.br",
      profile: "admin",
    });

    const user = getUser();
    if (user) {
      history.push("/dashboard");
    }
  }, [history]);

  function toChange() {
    setRegister((prevState) => !prevState);
  }

  return register ? (
    <Register toChange={toChange} />
  ) : (
    <Login toChange={toChange} />
  );
}

export default Auth;
