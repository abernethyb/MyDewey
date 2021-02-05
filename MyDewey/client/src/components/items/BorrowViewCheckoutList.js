import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const BorrowViewCheckoutList = () => {


    const { borrowViews, GetBorrowerViewCheckout, Checkin, HideCheckoutRequest } = useContext(ItemContext);

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

                                <p>{borrow.dueDate && `Due by ${new Date(borrow.dueDate).getHours() > 12 ? new Date(borrow.dueDate).getHours() - 12 : new Date(borrow.dueDate).getHours()}:${new Date(borrow.dueDate).getHours() > 12 ? new Date(borrow.dueDate).getMinutes() + " PM" : new Date(borrow.dueDate).getMinutes() + " AM"} on ${new Date(borrow.dueDate).getMonth() + 1}/${new Date(borrow.dueDate).getDate()}/${new Date(borrow.dueDate).getFullYear()}`}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}
                                {!borrow.checkinDate ?
                                    <Button onClick={(e) => { Checkin(borrow.checkoutId) }}>
                                        Return
                                </Button>
                                    :
                                    <p>Awaiting return verification.  Returned on {borrow.checkinDate}</p>
                                }

                            </div>
                            :
                            <div className="requestQueue" >
                                {/* < Link to={`item detai page TODO`}> */}
                                <p>{borrow.declined ? "DECLINED" : "PENDING"}</p>
                                <p>Item Name: {borrow.itemName}</p>
                                <p>Owner: {borrow.ownerUserName}</p>
                                <p>{borrow.checkoutDate && `Checked out at ${new Date(borrow.checkoutDate).getHours() > 12 ? new Date(borrow.checkoutDate).getHours() - 12 : new Date(borrow.checkoutDate).getHours()}:${new Date(borrow.checkoutDate).getHours() > 12 ? new Date(borrow.checkoutDate).getMinutes() + " PM" : new Date(borrow.checkoutDate).getMinutes() + " AM"} on ${new Date(borrow.checkoutDate).getMonth() + 1}/${new Date(borrow.checkoutDate).getDate()}/${new Date(borrow.checkoutDate).getFullYear()}`}</p>

                                <p>{borrow.dueDate && `Due By ${new Date(borrow.dueDate).getHours() > 12 ? new Date(borrow.dueDate).getHours() - 12 : new Date(borrow.dueDate).getHours()}:${new Date(borrow.dueDate).getHours() > 12 ? new Date(borrow.dueDate).getMinutes() + " PM" : new Date(borrow.dueDate).getMinutes() + " AM"} on ${new Date(borrow.dueDate).getMonth() + 1}/${new Date(borrow.dueDate).getDate()}/${new Date(borrow.dueDate).getFullYear()}`}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}
                                {borrow.declined ?
                                    <Button onClick={(e) => { HideCheckoutRequest(borrow.checkoutId) }}>
                                        Hide
                                    </Button>
                                    :
                                    <Button onClick={(e) => { HideCheckoutRequest(borrow.checkoutId) }}>
                                        Cancel Request
                                    </Button>
                                }

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
