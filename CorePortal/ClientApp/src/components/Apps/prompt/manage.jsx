import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function PMMANAGE() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ZPrompt Application - Management'})}</PageTitle>
        ZPROMPT APPLICATION - MANAGEMENT
    </div>
}