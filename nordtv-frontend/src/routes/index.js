import React from "react";
import { Switch, BrowserRouter, Redirect } from "react-router-dom";

import { NavBar } from "../Components";
import { Auth, DashBoard, ProductionAdd, ProductionList } from "../Pages";
import Route from "./routeWrapper";

export const Routes = () => (
  <BrowserRouter>
    <Route path="/dashboard/" component={NavBar} isPrivate />
    <Switch>
      <Route path="/login" exact component={Auth} />
      <Route path="/dashboard/" exact component={DashBoard} isPrivate />
      <Route
        path="/dashboard/addProductions"
        exact
        component={ProductionAdd}
        isPrivate
      />
      <Route
        path="/dashboard/productions"
        exact
        component={ProductionList}
        isPrivate
      />

      <Route path="/" exact component={() => <Redirect to="/login" />} />
    </Switch>
  </BrowserRouter>
);
