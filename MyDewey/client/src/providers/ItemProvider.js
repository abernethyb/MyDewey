import React, { useState, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";
import { useHistory } from "react-router-dom";

export const ItemContext = React.createContext();

export const ItemProvider = (props) => {
    const [items, setItems] = useState([]);
    const { getToken } = useContext(UserProfileContext);
    const history = useHistory();

    const getAllItems = () => {
        getToken().then((token) =>
            fetch(`/api/item`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then(resp => {
                // if (resp.ok) {
                return resp.json().then(setItems);
                // } else {

                //     (history.push(`/unauthorized`));
                //     //throw new Error("Unauthorized")
                // }
            })
        );
    }
    const getUserItems = () => {
        getToken().then((token) =>
            fetch(`/api/item/UserItems`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then(resp => {
                // if (resp.ok) {
                return resp.json().then(setItems);
                // } else {

                //     (history.push(`/unauthorized`));
                //     //throw new Error("Unauthorized")
                // }
            })
        );
    }
    const addItem = (item) => {
        return getToken().then((token) =>
            fetch("/api/item", {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(item)
            }).then(resp => {
                //TODO: 
                //when api returns item as response
                // if (resp.ok) {
                //return resp.json();
                // } else {
                //     (history.push(`/unauthorized`));
                // }
            }));
    };


    return (
        <ItemContext.Provider value={{ items, getAllItems, getUserItems, addItem }}>
            {props.children}
        </ItemContext.Provider>
    );
};