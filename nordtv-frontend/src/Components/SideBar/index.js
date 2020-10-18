import React from "react";
import {
  Divider,
  Drawer,
  IconButton,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
} from "@material-ui/core";

import {
  ListAltRounded as ListAltRoundedIcon,
  AddCircleOutlineRounded as AddCircleOutlineRoundedIcon,
  ArrowBackRounded as ArrowBackRoundedIcon,
  ExitToAppRounded as ExitToAppRoundedIcon,
} from "@material-ui/icons";

import { useHistory } from "react-router-dom";
import { useStyles } from "./style";

import { getUser, logout } from "../../Services/user";

// import { Container } from './styles';

function SideBar(props) {
  const user = getUser();

  const classes = useStyles();
  const history = useHistory();

  function navegation(location) {
    history.push(location);
    props.onClose();
  }

  function existApp(location) {
    logout();
    navegation("/");
  }

  return (
    <Drawer open={props.open} onClose={props.onClose}>
      <div className={classes.icon}>
        <IconButton edge="start" color="inherit" onClick={props.onClose}>
          <ArrowBackRoundedIcon />
        </IconButton>
      </div>
      <div className={classes.profile}>
        <h4>{user?.name}</h4>
        <p>{user.email}</p>
      </div>
      <Divider />
      <List>
        <ListItem
          button
          onClick={() => navegation("/dashboard/addProductions")}
        >
          <ListItemIcon>
            <AddCircleOutlineRoundedIcon />
          </ListItemIcon>
          <ListItemText primary={"Nova Produções"} />
        </ListItem>
        <ListItem button onClick={() => navegation("/dashboard/productions")}>
          <ListItemIcon>
            <ListAltRoundedIcon />
          </ListItemIcon>
          <ListItemText primary={"Minha Produções"} />
        </ListItem>
        <ListItem button onClick={existApp}>
          <ListItemIcon>
            <ExitToAppRoundedIcon />
          </ListItemIcon>
          <ListItemText primary={"Sair"} />
        </ListItem>
      </List>
    </Drawer>
  );
}

export default SideBar;
