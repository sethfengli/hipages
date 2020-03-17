import React, { Component } from 'react';
import Moment from 'react-moment';
import './JobCard.css';
import 'font-awesome/css/font-awesome.min.css';

export class AcceptedJobList extends Component {
    static displayName = AcceptedJobList.name;

    constructor(props) {
        super(props);
        this.state = { acceptedJobs: [], loading: true };
    }
    componentDidMount() {
        this.populateAcceptedJobs();
    }
    static renderJobCards(acceptedJobs) {

        let formatter = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
        });

        return (
        <React.Fragment>
        {acceptedJobs.map(acceptedJob =>
            <div key={acceptedJob.id} id={acceptedJob.id} className="job-card">
                <div className="name-and-time">
                    <div className="first-initial-letter">{acceptedJob.contactName.charAt(0)}</div>
                        <div className="name-create-time">
                            <div className="firstname">{acceptedJob.contactName}</div>  
                            <div className="create-time"> <Moment format="MMMM DD YYYY @ h:mm a">
                                                            {acceptedJob.createdAt}
                                                        </Moment></div> 
                    </div>
                </div>
                <div className="suburb-and-category">
                    <i className="fa fa-map-marker font-icon" aria-hidden="true" ></i>
                    {acceptedJob.suburb.name} &nbsp;
                    {acceptedJob.suburb.postCode}  &nbsp; &nbsp;
                    <i className="fa fa-briefcase font-icon" aria-hidden="true"></i>
                    {acceptedJob.category.name}  &nbsp; &nbsp;
                    Job ID: {acceptedJob.id}  &nbsp; &nbsp;
                    {formatter.format(acceptedJob.price)} &nbsp;  Lead Inviation
                </div>
                <div className="phone-and-email">
                    <i className="fa fa-phone font-icon" aria-hidden="true" ></i>
                    {acceptedJob.contactPhone}  &nbsp; &nbsp;
                    <i className="fa fa-envelope font-icon" aria-hidden="true"></i>
                    {acceptedJob.contactEmail} 
                    <p>{acceptedJob.description}</p>
                </div>
            </div>        
        )}
        </React.Fragment>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AcceptedJobList.renderJobCards(this.state.acceptedJobs);

        return (  <React.Fragment>{contents} </React.Fragment> );
    }

    async populateAcceptedJobs() {
        const response = await fetch('api/JobList/accepted');
        const data = await response.json();
        this.setState({ acceptedJobs: data, loading: false });
    }
}
