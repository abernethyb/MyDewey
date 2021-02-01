import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";
import Login from "./Login";
import Register from "./Register";
import HiThere from "./HiThere";
import ItemList from "./items/ItemListAll";
import UserItemList from "./items/UserItemList";

export default function ApplicationViews() {
    const { isLoggedIn } = useContext(UserProfileContext);

    return (
        <main>
            <Switch>

                {/* "/" will change to dashboard view later */}

                <Route path="/" exact>
                    {isLoggedIn ? <ItemList /> : <Redirect to="/login" />}
                </Route>

                {/* Items */}
                <Route path="/your_library" exact>
                    {isLoggedIn ? <UserItemList /> : <Redirect to="/login" />}
                </Route>

                {/* Auth */}

                <Route path="/login" exact>
                    <Login />
                </Route>

                <Route path="/register" exact>
                    <Register />
                </Route>

                <Route path="/unauthorized" exact>
                    {isLoggedIn ? <HiThere /> : <Redirect to="/login" />}
                </Route>
            </Switch>
        </main>
    );
};
