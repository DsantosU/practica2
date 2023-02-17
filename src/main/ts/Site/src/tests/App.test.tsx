// eslint-disable-next-line import/no-extraneous-dependencies
import { shallow } from 'enzyme';
import * as React from 'react';
import App from '../App';

export { };

describe('<App/> tests', () => {
  test('should render correctly', () => {
    const wrapper = shallow(<App />);

    expect(wrapper).toMatchSnapshot();
  });
});
