import React from "react";
import { Button, Paper, TextField } from "@material-ui/core";
import { useStyles } from "./style";

import logo from "../../../Assets/logo-avanade.png";
import { Link } from "react-router-dom";

function Login(props) {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Paper elevation={3} className={classes.paper} component={"form"}>
        <div className={classes.logo}>
          <img src={logo} alt="logo" />
        </div>
        <div className={classes.inputs}>
          <TextField required label="Email" variant="outlined" fullWidth />
          <TextField
            label="Password"
            type="password"
            autoComplete="current-password"
            variant="outlined"
            fullWidth
          />
        </div>
        <div className={classes.footer}>
          <Button
            className={classes.button}
            variant="contained"
            color="primary"
            fullWidth
          >
            Entrar
          </Button>
          <Link className={classes.link} onClick={props.toChange}>
            Ainda não tem Conta? Registre-se
          </Link>
        </div>
      </Paper>
    </div>
  );
}

export default Login;
