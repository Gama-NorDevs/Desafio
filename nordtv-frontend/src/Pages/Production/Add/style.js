import { makeStyles } from "@material-ui/core/styles";

export const useStyles = makeStyles((theme) => ({
  root: {
    // height: "100vh",
    padding: 10,
    // backgroundColor: "#dadada",
  },
  paper: {
    padding: 10,
    margin: "0 3rem",
  },

  button: {
    display: "flex",
    justifyContent: "space-between",
    margin: "1rem 3rem",
  },
}));
