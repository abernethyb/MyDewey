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


    return (
        <ItemContext.Provider value={{ items, getAllItems, }}>
            {props.children}
        </ItemContext.Provider>
    );
};