import React from "react";
import { Button, Paper, TextField } from "@material-ui/core";
import { useStyles } from "./style";
import { useFormik } from "formik";
import { initialValues, validationSchema } from "./helper";
import { api } from "../../../Services/api";

import logo from "../../../Assets/logo-avanade.png";
import { Link } from "react-router-dom";

function Login(props) {
  const classes = useStyles();

  const formik = useFormik({
    initialValues,
    validationSchema,
    onSubmit: async (values) => {
      try {
        const user = await api.post("/login", values);

        console.log(user);
      } catch (e) {
        console.log(e);
      }
    },
  });

  return (
    <div className={classes.root}>
      <Paper
        elevation={3}
        className={classes.paper}
        component={"form"}
        noValidate
        onSubmit={formik.handleSubmit}
      >
        <div className={classes.logo}>
          <img src={logo} alt="logo" />
        </div>
        <div className={classes.inputs}>
          <TextField
            required
            label="Email"
            variant="outlined"
            fullWidth
            name="login"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.login}
            error={formik.errors?.login && formik.touched?.login}
            helperText={
              formik.errors?.login && formik.touched?.login
                ? formik.errors?.login
                : null
            }
          />
          <TextField
            label="Password"
            type="password"
            autoComplete="current-password"
            variant="outlined"
            fullWidth
            name="password"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.password}
            error={formik.errors?.password && formik.touched?.password}
            helperText={
              formik.errors?.password && formik.touched?.password
                ? formik.errors?.password
                : null
            }
          />
        </div>
        <div className={classes.footer}>
          <Button
            className={classes.button}
            variant="contained"
            color="primary"
            type="submit"
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
