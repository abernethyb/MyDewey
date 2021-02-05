import React, { useState, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";
import { useHistory } from "react-router-dom";

export const ItemContext = React.createContext();

export const ItemProvider = (props) => {
    const [items, setItems] = useState([]);
    const [requests, setRequests] = useState([]);
    const [borrowViews, setBorrowViews] = useState([]);
    const [lenderViews, setLenderViews] = useState([]);
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
    const getNonUserItems = () => {
        getToken().then((token) =>
            fetch(`/api/item/NonUserItems`, {
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

    //Checkout Handling //

    const RequestCheckout = (itemId) => {
        return getToken().then((token) =>
            fetch(`/api/item/requestCheckout/${itemId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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

    const getCheckoutRequests = () => {
        getToken().then((token) =>
            fetch(`/api/item/CheckoutRequests`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then(resp => {
                // if (resp.ok) {
                return resp.json().then(setRequests);
                // } else {

                //     (history.push(`/unauthorized`));
                //     //throw new Error("Unauthorized")
                // }
            })
        );
    }
    const GetBorrowerViewCheckout = () => {
        getToken().then((token) =>
            fetch(`/api/item/BorrowerViewCheckout`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then(resp => {
                // if (resp.ok) {
                return resp.json().then(setBorrowViews);
                // } else {

                //     (history.push(`/unauthorized`));
                //     //throw new Error("Unauthorized")
                // }
            })
        );
    }
    const GetLenderViewCheckout = () => {
        getToken().then((token) =>
            fetch(`/api/item/LenderViewCheckout`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then(resp => {
                // if (resp.ok) {
                return resp.json().then(setLenderViews);
                // } else {

                //     (history.push(`/unauthorized`));
                //     //throw new Error("Unauthorized")
                // }
            })
        );
    }
    const AddToCheckoutQueue = (checkoutId) => {
        return getToken().then((token) =>
            fetch(`/api/item/AddToCheckoutQueue/${checkoutId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
    const RemoveFromCheckoutQueue = (checkoutId) => {
        return getToken().then((token) =>
            fetch(`/api/item/RemoveFromCheckoutQueue/${checkoutId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
    const DeclineCheckoutRequest = (checkoutId) => {
        return getToken().then((token) =>
            fetch(`/api/item/DeclineCheckoutRequest/${checkoutId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
    const HideCheckoutRequest = (checkoutId) => {
        return getToken().then((token) =>
            fetch(`/api/item/HideCheckoutRequest/${checkoutId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
    const Checkin = (checkoutId) => {
        return getToken().then((token) =>
            fetch(`/api/item/Checkin/${checkoutId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
    const ApproveCheckout = (checkoutId, itemId) => {
        return getToken().then((token) =>
            fetch(`/api/item/ApproveCheckout/${checkoutId}/${itemId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
    const VerifyCheckin = (checkoutId, itemId) => {
        return getToken().then((token) =>
            fetch(`/api/item/VerifyCheckin/${checkoutId}/${itemId}`, {
                method: "POST",
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json",
                }
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
        <ItemContext.Provider value={{ items, requests, borrowViews, lenderViews, getAllItems, getUserItems, addItem, getNonUserItems, RequestCheckout, getCheckoutRequests, AddToCheckoutQueue, RemoveFromCheckoutQueue, ApproveCheckout, GetBorrowerViewCheckout, GetLenderViewCheckout, Checkin, VerifyCheckin, DeclineCheckoutRequest, HideCheckoutRequest }}>
            {props.children}
        </ItemContext.Provider>
    );
};