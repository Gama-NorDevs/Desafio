import React, { useState } from "react";

import { AppBar, IconButton, Toolbar } from "@material-ui/core";
import { Menu as MenuIcon } from "@material-ui/icons";

import { useStyles } from "./style";
import { Link } from "react-router-dom";
import SideBar from "../SideBar";

function NavBar() {
  const classes = useStyles();
  const [open, setOpen] = useState(false);

  const toggleSideBar = (event) => {
    if (
      event &&
      event.type === "keydown" &&
      (event.key === "Tab" || event.key === "Shift")
    ) {
      return;
    }

    setOpen((prevState) => !prevState);
  };

  return (
    <div className={classes.root}>
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar>
          <IconButton
            edge="start"
            className={classes.menuButton}
            color="inherit"
            onClick={toggleSideBar}
          >
            <MenuIcon />
          </IconButton>
          <Link to="/dashboard" className={classes.link}>
            <h3>NordTV</h3>
          </Link>
        </Toolbar>
      </AppBar>
      <Toolbar />
      <SideBar open={open} onClose={toggleSideBar} />
    </div>
  );
}

export default NavBar;
