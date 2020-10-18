import React from "react";
import { Route, Redirect } from "react-router-dom";
import { getUser } from "../Services/user";

function RouteWrapper({ component: Component, isPrivate, ...rest }) {
  const user = getUser();

  if (isPrivate) {
    if (user) {
      return <Route {...rest} component={Component} />;
    }
  } else {
    return <Route {...rest} component={Component} />;
  }
  return <Redirect to="/login" />;
}

RouteWrapper.defaultProps = {
  isPrivate: false,
};

export default RouteWrapper;
