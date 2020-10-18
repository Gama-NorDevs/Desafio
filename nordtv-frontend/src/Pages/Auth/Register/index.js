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

function Login(props) {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Paper elevation={3} className={classes.paper} component={"form"}>
        <IconButton aria-label="back">
          <ArrowBackRoundedIcon />
        </IconButton>
        <div className={classes.logo}>
          <img src={logo} alt="logo" />
          <h3>Registro</h3>
        </div>
        <div className={classes.inputs}>
          <TextField required label="Nome" variant="outlined" fullWidth />
          <FormControl required variant="outlined" fullWidth>
            <InputLabel id="select-label">Sexo</InputLabel>
            <Select labelId="select-label" label="Sexo">
              <MenuItem value="">
                <em></em>
              </MenuItem>
              <MenuItem value={"F"}>Feminino</MenuItem>
              <MenuItem value={"M"}>Maculino</MenuItem>
            </Select>
          </FormControl>
          <TextField required label="Cachê" variant="outlined" fullWidth />
          <TextField
            required
            label="Email"
            type="email"
            variant="outlined"
            fullWidth
          />
          <TextField
            required
            label="Password"
            type="password"
            autoComplete="current-password"
            variant="outlined"
            fullWidth
          />
        </div>

        <Button
          className={classes.button}
          variant="contained"
          color="primary"
          fullWidth
        >
          Registrar
        </Button>
      </Paper>
    </div>
  );
}

export default Login;
