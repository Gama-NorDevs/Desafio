import { makeStyles } from "@material-ui/core/styles";

export const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  //   appBar: {
  //     zIndex: theme.zIndex.drawer + 1,
  //   },
  title: {
    flexGrow: 1,
  },
  link: { textDecoration: "none", color: "white" },
}));
