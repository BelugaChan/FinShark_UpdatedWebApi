import React from "react";
import Table from "../../Components/Table/Table";
import RatioList from "../../Components/RatioList/RatioList";
import { testIncomeStatementData } from "../../Components/Table/TestData";

interface Props {}

const tableConfig = [
  {
    label: "Market Cap",
    render: (company: any) => company.marketCapTTM,
    subTitle: "Total value of all a company's shares of stock",
  },
];
const DesignPage = (props: Props) => {
  return (
    <>
      <h1>FinShark design page</h1>
      <RatioList data={testIncomeStatementData} config={tableConfig} />
      <Table data={testIncomeStatementData} configs={tableConfig} />
      <h2>
        Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt
        deleniti quibusdam cum. Praesentium voluptatum, assumenda omnis aperiam
        error tempore enim, pariatur iure ullam ad hic at, doloremque
        consequuntur nobis reiciendis.
      </h2>
    </>
  );
};

export default DesignPage;
