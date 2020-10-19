import React from "react";
import {
  Button,
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
} from "@material-ui/core";
import ArrowBackRoundedIcon from "@material-ui/icons/ArrowBackRounded";
import { useStyles } from "./style";

import logo from "../../../Assets/logo-avanade.png";
import { useFormik } from "formik";
import { initialValues, validationSchema } from "./helper";
import { api } from "../../../Services/api";

function Login(props) {
  const classes = useStyles();

  const formik = useFormik({
    initialValues,
    validationSchema,
    onSubmit: async (values) => {
      const { email, name, password, profile, ...actor } = values;
      try {
        const newActor = await api
          .post("/user", { email, name, password, profile })
          .then((result) => {
            console.log(result);
            api.post("/actor", { ...actor, idUser: result.data.id_user });
          });

        console.log(newActor);
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
        <IconButton aria-label="back">
          <ArrowBackRoundedIcon />
        </IconButton>
        <div className={classes.logo}>
          <img src={logo} alt="logo" />
          <h3>Registro</h3>
        </div>
        <div className={classes.inputs}>
          <TextField
            required
            label="Nome"
            variant="outlined"
            fullWidth
            name="name"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.name}
            error={formik.errors?.name && formik.touched?.name}
            helperText={
              formik.errors?.name && formik.touched?.name
                ? formik.errors?.name
                : null
            }
          />
          <FormControl required variant="outlined" fullWidth>
            <InputLabel id="select-label">Sexo</InputLabel>
            <Select
              labelId="select-label"
              label="Sexo"
              name="sex"
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.sex}
              error={formik.errors?.sex && formik.touched?.sex}
              helperText={
                formik.errors?.sex && formik.touched?.sex
                  ? formik.errors?.sex
                  : null
              }
            >
              <MenuItem value="">
                <em></em>
              </MenuItem>
              <MenuItem value={"F"}>Feminino</MenuItem>
              <MenuItem value={"M"}>Maculino</MenuItem>
            </Select>
          </FormControl>
          <TextField
            required
            label="Cachê"
            variant="outlined"
            fullWidth
            name="amount"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.amount}
            error={formik.errors?.amount && formik.touched?.amount}
            helperText={
              formik.errors?.amount && formik.touched?.amount
                ? formik.errors?.amount
                : null
            }
          />
          <TextField
            required
            label="Email"
            type="email"
            variant="outlined"
            fullWidth
            name="email"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.email}
            error={formik.errors?.email && formik.touched?.email}
            helperText={
              formik.errors?.email && formik.touched?.email
                ? formik.errors?.email
                : null
            }
          />
          <TextField
            required
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

        <Button
          className={classes.button}
          variant="contained"
          color="primary"
          fullWidth
          type="submit"
        >
          Registrar
        </Button>
      </Paper>
    </div>
  );
}

export default Login;
