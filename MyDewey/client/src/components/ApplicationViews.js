import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";
import Login from "./Login";
import Register from "./Register";
import HiThere from "./HiThere";
import ItemList from "./items/PublicLibrary";
import UserItemList from "./items/PersonalLibrary";
import AddItem from "./items/NewItemForm";
import RequestList from "./items/RequestList";
import BorrowViewCheckoutList from "./items/BorrowViewCheckoutList";
import LenderViewCheckoutList from "./items/LenderViewCheckoutList";

export default function ApplicationViews() {
    const { isLoggedIn } = useContext(UserProfileContext);

    return (
        <main>
            <Switch>

                {/* "/" will change to dashboard view later */}

                {/* Items */}
                <Route path="/" exact>
                    {isLoggedIn ? <RequestList /> : <Redirect to="/login" />}
                </Route>
                <Route path="/requests" exact>
                    {isLoggedIn ? <RequestList /> : <Redirect to="/login" />}
                </Route>
                <Route path="/public_library" exact>
                    {isLoggedIn ? <ItemList /> : <Redirect to="/login" />}
                </Route>
                <Route path="/currently_borrowing" exact>
                    {isLoggedIn ? <BorrowViewCheckoutList /> : <Redirect to="/login" />}
                </Route>
                <Route path="/currently_lending" exact>
                    {isLoggedIn ? <LenderViewCheckoutList /> : <Redirect to="/login" />}
                </Route>


                <Route path="/your_library" exact>
                    {isLoggedIn ? <UserItemList /> : <Redirect to="/login" />}
                </Route>
                <Route path="/your_library/new" exact>
                    {isLoggedIn ? <AddItem /> : <Redirect to="/login" />}
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
