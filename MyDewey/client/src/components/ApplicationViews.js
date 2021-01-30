import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";
import Login from "./Login";
import Register from "./Register";
import HiThere from "./HiThere";
import ItemList from "./items/Item";

export default function ApplicationViews() {
    const { isLoggedIn } = useContext(UserProfileContext);

    return (
        <main>
            <Switch>

                <Route path="/">
                    <ItemList />
                </Route>
                {/* Auth */}

                <Route path="/login">
                    <Login />
                </Route>

                <Route path="/register">
                    <Register />
                </Route>

                <Route path="/unauthorized" exact>
                    {isLoggedIn ? <HiThere /> : <Redirect to="/login" />}
                </Route>
            </Switch>
        </main>
    );
};
