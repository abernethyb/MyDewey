import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const BorrowViewCheckoutList = () => {


    const { borrowViews, GetBorrowerViewCheckout } = useContext(ItemContext);

    const history = useHistory();


    useEffect(() => {

        GetBorrowerViewCheckout();
    }, []);

    if (!borrowViews) {
        return null;
    }

    return (
        <>

            <div className="itemList">
                <div className="itemListTop">
                    <h2>Items You're Currently Borrowing</h2>

                </div>

                {borrowViews.map((borrow) => (
                    <div key={borrow.id} >
                        {borrow.checkoutDate
                            ?
                            <div className="items" >
                                {/* < Link to={`item detai page TODO`}> */}
                                <p>Item Name: {borrow.itemName}</p>
                                <p>Owner: {borrow.ownerUserName}</p>
                                <p>{borrow.checkoutDate && `Checked out at ${new Date(borrow.checkoutDate).getHours() > 12 ? new Date(borrow.checkoutDate).getHours() - 12 : new Date(borrow.checkoutDate).getHours()}:${new Date(borrow.checkoutDate).getHours() > 12 ? new Date(borrow.checkoutDate).getMinutes() + " PM" : new Date(borrow.checkoutDate).getMinutes() + " AM"} on ${new Date(borrow.checkoutDate).getMonth() + 1}/${new Date(borrow.checkoutDate).getDate()}/${new Date(borrow.checkoutDate).getFullYear()}`}</p>
                                <p>Due Date: {borrow.dueDate}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}

                            </div>
                            :
                            <div className="requestQueue" >
                                {/* < Link to={`item detai page TODO`}> */}
                                <p>{borrow.declined ? "DECLINED" : "PENDING"}</p>
                                <p>Item Name: {borrow.itemName}</p>
                                <p>Owner: {borrow.ownerUserName}</p>
                                <p>{borrow.checkoutDate && `Checked out at ${new Date(borrow.checkoutDate).getHours() > 12 ? new Date(borrow.checkoutDate).getHours() - 12 : new Date(borrow.checkoutDate).getHours()}:${new Date(borrow.checkoutDate).getHours() > 12 ? new Date(borrow.checkoutDate).getMinutes() + " PM" : new Date(borrow.checkoutDate).getMinutes() + " AM"} on ${new Date(borrow.checkoutDate).getMonth() + 1}/${new Date(borrow.checkoutDate).getDate()}/${new Date(borrow.checkoutDate).getFullYear()}`}</p>
                                <p>Due Date: {borrow.dueDate}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}

                            </div>
                        }
                    </div>



                ))
                }
            </div>

        </>
    );
};

export default BorrowViewCheckoutList;
