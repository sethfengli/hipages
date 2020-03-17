import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { InvitedJobList } from './components/InvitedJobList';
import { AcceptedJobList } from './components/AcceptedJobList';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={InvitedJobList} />
        <Route path='/accepted' component={AcceptedJobList} />
      </Layout>
    );
  }
}
