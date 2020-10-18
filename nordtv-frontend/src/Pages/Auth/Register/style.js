import { makeStyles } from "@material-ui/core/styles";

export const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    width: "100%",
    height: "100vh",
  },
  paper: {
    width: "50%",
    padding: "1rem",
  },
  logo: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    "& img": { width: "20%", maxWidth: 250, marginLeft: "1rem" },
    marginBottom: "1rem",
  },

  inputs: { "& div": { marginBottom: 5 } },

  button: { marginTop: "1rem" },
}));
