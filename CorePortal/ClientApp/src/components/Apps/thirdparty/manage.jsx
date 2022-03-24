import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function TPMANAGE() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ThirdParty Application - Management'})}</PageTitle>
        THIRDPARTY APPLICATION - MANAGEMENT
    </div>
}